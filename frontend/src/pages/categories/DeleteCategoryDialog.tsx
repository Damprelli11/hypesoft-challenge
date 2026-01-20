import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { Trash } from "lucide-react";
import { toast } from "sonner";
import { useDeleteCategory } from "@/hooks/useDeleteCategory";
import type { Category } from "@/types/category";
import { useState } from "react";

interface DeleteCategoryDialogProps {
  category: Category;
}

export function DeleteCategoryDialog({ category }: DeleteCategoryDialogProps) {
  const { mutateAsync, isPending } = useDeleteCategory();
  const [open, setOpen] = useState(false);

  async function handleDelete() {
    try {
      await mutateAsync(category.id);
      toast.success("Categoria removida com sucesso!");
      setOpen(false);
    } catch {
      toast.error("Erro ao remover categoria");
    }
  }

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button variant="ghost" size="icon">
          <Trash size={16} className="text-red-500" />
        </Button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>Excluir categoria</DialogTitle>
        </DialogHeader>

        <p className="text-sm text-zinc-400">
          Tem certeza que deseja excluir{" "}
          <strong className="text-zinc-400">{category.name}</strong>?
        </p>

        <div className="flex justify-end gap-2 mt-4">
          <Button
            variant="secondary"
            onClick={() => setOpen(false)}
            disabled={isPending}
          >
            Cancelar
          </Button>

          <Button
            variant="destructive"
            onClick={handleDelete}
            disabled={isPending}
          >
            {isPending ? "Excluindo..." : "Excluir"}
          </Button>
        </div>
      </DialogContent>
    </Dialog>
  );
}