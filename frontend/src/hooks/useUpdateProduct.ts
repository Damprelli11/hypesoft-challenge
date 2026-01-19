import { useMutation, useQueryClient } from "@tanstack/react-query";
import { api } from "@/services/api";
import type { ProductFormData } from "@/schemas/productSchema";

interface UpdateProductParams {
  id: string;
  data: ProductFormData;
}

export function useUpdateProduct() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async ({ id, data }: UpdateProductParams) => {
      await api.put(`/products/${id}`, data);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["products"] });
    },
  });
}
