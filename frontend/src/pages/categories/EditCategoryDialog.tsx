import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { Pencil } from "lucide-react";
import { toast } from "sonner";
import { CategoryForm } from "./CategoryForm";
import { useUpdateCategory } from "@/hooks/useUpdateCategory";
import type { Category } from "@/types/category";
import { useState } from "react";
import type { CategoryFormData } from "@/schemas/categorySchema";

interface EditCategoryDialogProps {
  category: Category;
}

export function EditCategoryDialog({ category }: EditCategoryDialogProps) {
  const { mutateAsync, isPending } = useUpdateCategory();
  const [open, setOpen] = useState(false);

  async function handleEdit(data: CategoryFormData ) {
    try {
      await mutateAsync({
        id: category.id,
        data,
      });

      toast.success("Categoria atualizada com sucesso!");
      setOpen(false);
    } catch {
      toast.error("Erro ao atualizar categoria");
      throw new Error(); //impede reset se falhar
    }
  }

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button variant="ghost" size="icon">
          <Pencil size={16} />
        </Button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>Editar categoria</DialogTitle>
        </DialogHeader>

        <CategoryForm
          onSubmit={handleEdit}
          isLoading={isPending}
          initialData={{ name: category.name }}
        />
      </DialogContent>
    </Dialog>
  );
}
