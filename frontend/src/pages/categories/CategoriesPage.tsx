import { useCategories } from "@/hooks/useCategories";

export default function CategoriesPage() {
  const { data, isLoading } = useCategories();

  if (isLoading) return <p>Carregando...</p>;

  return (
    <div>
      <h1 className="text-2xl font-bold mb-4">Categorias</h1>

      <ul className="space-y-2">
        {data?.map((category) => (
          <li key={category.id} className="border border-zinc-800 rounded p-3">
            {category.name}
          </li>
        ))}
      </ul>
    </div>
  );
}
