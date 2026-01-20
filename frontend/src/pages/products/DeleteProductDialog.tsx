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
import { useDeleteProduct } from "@/hooks/useDeleteProduct";
import type { Product } from "@/types/product";
import { useState } from "react";

interface DeleteProductDialogProps {
  product: Product;
}

export function DeleteProductDialog({ product }: DeleteProductDialogProps) {
  const { mutateAsync, isPending } = useDeleteProduct();
  const [open, setOpen] = useState(false);

  async function handleDelete() {
    try {
      await mutateAsync(product.id);
      toast.success("Produto removido com sucesso!");
      setOpen(false);
    } catch {
      toast.error("Erro ao remover produto");
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
          <DialogTitle>Excluir produto</DialogTitle>
        </DialogHeader>

        <p className="text-sm text-zinc-400">
          Tem certeza que deseja excluir{" "}
          <strong className="text-zinc-400">{product.name}</strong>?
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
