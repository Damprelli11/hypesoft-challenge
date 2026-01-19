import { z } from "zod";

export const productSchema = z.object({
  name: z.string().min(1, "Name is required"),
  description: z.string().min(1, "Description is required"),
  category: z.string().min(1, "Category is required"),
  price: z.number().positive("Price must be positive"),
  stock: z.number().int().min(0),
});

/**
 * 👇 Tipo inferido DIRETO do schema
 */
export type ProductFormData = z.infer<typeof productSchema>;
