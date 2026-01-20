import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { ProductForm } from "./ProductForm";
import { useCreateProduct } from "@/hooks/useCreateProduct";
import { toast } from "sonner";
import { useState } from "react";
import type { ProductFormData } from "@/schemas/productSchema";

export function CreateProductDialog() {
  const { mutateAsync, isPending } = useCreateProduct();
  const [open, setOpen] = useState(false);

  async function handleCreate(data: ProductFormData) {
    try {
      await mutateAsync(data);
      toast.success("Produto criado com sucesso!");
      setOpen(false); //fecha o modal
    } catch {
      toast.error("Erro ao criar produto");
      throw new Error(); // impede reset se falhar
    }
  }

  return (
    <Dialog open={open} onOpenChange={setOpen}>
      <DialogTrigger asChild>
        <Button>+ Novo</Button>
      </DialogTrigger>

      <DialogContent>
        <DialogHeader>
          <DialogTitle>+ Novo</DialogTitle>
        </DialogHeader>

        <ProductForm onSubmit={handleCreate} isLoading={isPending} />
      </DialogContent>
    </Dialog>
  );
}
