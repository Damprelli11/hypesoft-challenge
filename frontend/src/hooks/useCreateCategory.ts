import { useMutation, useQueryClient } from "@tanstack/react-query";
import { api } from "@/services/api";
import type { CategoryFormData } from "@/schemas/categorySchema";

export function useCreateCategory() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (data: CategoryFormData) => {
      const response = await api.post("/categories", data);
      return response.data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["categories"] });
    },
  });
}
