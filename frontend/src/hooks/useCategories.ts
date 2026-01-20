import { useQuery } from "@tanstack/react-query";
import { api } from "@/services/api";
import type { Category } from "@/types/category";

export function useCategories() {
  return useQuery<Category[]>({
    queryKey: ["categories"],
    queryFn: async () => {
      const response = await api.get("/categories");
      return response.data;
    },
  });
}