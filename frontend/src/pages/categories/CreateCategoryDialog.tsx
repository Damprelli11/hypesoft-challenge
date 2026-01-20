import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { toast } from "sonner";
import { CategoryForm } from "./CategoryForm";
import { useCreateCategory } from "@/hooks/useCreateCategory";
import type { CategoryFormData } from "@/schemas/categorySchema";
import { useState } from "react";

export function CreateCategoryDialog() {
  const { mutateAsync, isPending } = useCreateCategory();
  const [open, setOpen] = useState(false);

  async function handleCreate(data: CategoryFormData) {
    try {
      await mutateAsync(data);
      toast.success("Categoria criada com sucesso!");
      setOpen(false);
    } catch {
      toast.error("Erro ao criar categoria");
    }
  }

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button>Nova Categoria</Button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>Nova Categoria</DialogTitle>
        </DialogHeader>

        <CategoryForm onSubmit={handleCreate} isLoading={isPending} />
      </DialogContent>
    </Dialog>
  );
}
