import { useQuery } from "@tanstack/react-query";
import { api } from "@/services/api";
import type { Product } from "@/types/product";

export function useProducts() {
  return useQuery<Product[]>({
    queryKey: ["products"],
    queryFn: async () => {
      const response = await api.get("/products");

      return response.data;
    },
  });
}
