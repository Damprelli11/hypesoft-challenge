import { useQuery } from "@tanstack/react-query";
import { api } from "@/services/api";
import type { Product } from "@/types/product";

async function fetchProducts(): Promise<Product[]> {
  const response = await api.get("/products");
  return response.data;
}

export function useProducts() {
  return useQuery({
    queryKey: ["products"],
    queryFn: fetchProducts,
  });
}
