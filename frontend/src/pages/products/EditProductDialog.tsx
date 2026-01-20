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
import { ProductForm } from "./ProductForm";
import { useUpdateProduct } from "@/hooks/useUpdateProduct";
import type { Product } from "@/types/product";
import { useState } from "react";
import type { ProductFormData } from "@/schemas/productSchema";


interface EditProductDialogProps {
  product: Product;
}

export function EditProductDialog({ product }: EditProductDialogProps) {
  const { mutateAsync, isPending } = useUpdateProduct();
  const [open, setOpen] = useState(false);

  async function handleEdit(data: ProductFormData) {
    try {
      await mutateAsync({
        id: product.id,
        data,
      });

      toast.success("Produto atualizado com sucesso!");
      setOpen(false); //fecha o modal
    } catch {
      toast.error("Erro ao atualizar produto");
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
          <DialogTitle>Editar produto</DialogTitle>
        </DialogHeader>

        <ProductForm
          onSubmit={handleEdit}
          isLoading={isPending}
          initialData={{
            name: product.name,
            description: product.description,
            price: product.price,
            category: product.category,
            stock: product.stock,
          }}
        />
      </DialogContent>
    </Dialog>
  );
}
