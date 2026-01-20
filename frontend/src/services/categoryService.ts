import type { Category } from "@/types/category";

const mockCategories: Category[] = [
  { id: "1", name: "Eletrônicos" },
  { id: "2", name: "Roupas" },
  { id: "3", name: "Alimentos" },
];

export async function getCategories() {
  await new Promise((resolve) => setTimeout(resolve, 300));
  return mockCategories;
}
