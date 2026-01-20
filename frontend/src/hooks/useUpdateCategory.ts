import { useMutation, useQueryClient } from "@tanstack/react-query";
import { api } from "@/services/api";

interface UpdateCategoryParams {
  id: string;
  data: {
    name: string;
  };
}

export function useUpdateCategory() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async ({ id, data }: UpdateCategoryParams) => {
      await api.put(`/categories/${id}`, data);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["categories"] });
    },
  });
}
