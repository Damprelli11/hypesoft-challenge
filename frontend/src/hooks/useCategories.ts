import { useQuery } from "@tanstack/react-query";
import { api } from "@/services/api";
import type { Category } from "@/types/category";

/**
 * Custom hook to fetch all categories using React Query.
 * Caches the data and provides loading/error states.
 */
export function useCategories() {
  return useQuery<Category[]>({
    queryKey: ["categories"],
    queryFn: async () => {
      const response = await api.get("/categories");
      return response.data;
    },
  });
}