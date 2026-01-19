import { useMutation, useQueryClient } from "@tanstack/react-query";
import { api } from "@/services/api";
import type { ProductFormData } from "@/schemas/productSchema";

export function useCreateProduct() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (data: ProductFormData) => {
      const response = await api.post("/products", data);
      return response.data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["products"] });
    },
  });
}
