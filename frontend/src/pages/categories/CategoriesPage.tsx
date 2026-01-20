import { useCategories } from "@/hooks/useCategories";
import { CreateCategoryDialog } from "./CreateCategoryDialog";
import { EditCategoryDialog } from "./EditCategoryDialog";

export default function CategoriesPage() {
  const { data, isLoading, error } = useCategories();

  if (isLoading) {
    return <p className="text-zinc-400">Carregando categorias...</p>;
  }

  if (error) {
    return <p className="text-red-500">Erro ao carregar categorias</p>;
  }

  return (
    <div>
      <div className="flex items-center justify-between mb-4">
        <h1 className="text-2xl font-bold">Categorias</h1>
        <CreateCategoryDialog />
      </div>

      <div className="rounded-lg border border-zinc-800 overflow-hidden">
        <table className="w-full text-sm">
          <thead className="bg-zinc-900 text-zinc-400">
            <tr>
              <th className="p-3 text-left">Nome</th>
              <th className="p-3 text-right">Ações</th>
            </tr>
          </thead>

          <tbody>
            {data?.map((category) => (
              <tr
                key={category.id}
                className="border-t border-zinc-800 hover:bg-zinc-100"
              >
                <td className="p-3">{category.name}</td>

                <td className="p-3 text-right">
                  <EditCategoryDialog category={category} />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
