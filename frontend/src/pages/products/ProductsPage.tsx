import { useProducts } from "@/hooks/useProducts";
import { CreateProductDialog } from "@/pages/products/CreateProductDialog";
import { EditProductDialog } from "./EditProductDialog";
import { DeleteProductDialog } from "./DeleteProductDialog";
import { useState } from "react";


export default function ProductsPage() {
  const [search, setSearch] = useState("");
  const { data, isLoading, error } = useProducts();

  if (isLoading) {
    return <p className="text-zinc-400">Carregando produtos...</p>;
  }

  if (error) {
    return <p className="text-red-500">Erro ao carregar produtos</p>;
  }

  const filteredProducts = data?.filter((product) =>
    product.name.toLowerCase().includes(search.toLowerCase()),
  );

  return (
    <div>
      <div className="flex items-center justify-between mb-4">
        <h1 className="text-2xl font-bold mb-4">Produtos</h1>
        <input
          placeholder="Buscar"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          className="bg-zinc-100 border border-zinc-800 rounded-md px-3 py-2 text-sm focus:outline-none focus:ring-1 focus:ring-zinc-600"
        />
        <CreateProductDialog />
      </div>
      <div className="rounded-lg border border-zinc-800 overflow-hidden">
        <table className="w-full text-sm">
          <thead className="bg-zinc-900 text-zinc-400">
            <tr>
              <th className="p-3 text-left">Nome</th>
              <th className="p-3 text-left">Categoria</th>
              <th className="p-3 text-left">Preço</th>
              <th className="p-3 text-left">Estoque</th>
              <th className="p-3 text-left">Ações</th>
            </tr>
          </thead>

          <tbody>
            {filteredProducts?.map((product) => (
              <tr
                key={product.id}
                className="border-t border-zinc-800 hover:bg-zinc-100"
              >
                <td className="p-3">{product.name}</td>
                <td className="p-3">{product.category}</td>
                <td className="p-3">R$ {product.price.toFixed(2)}</td>
                <td className="p-3">{product.stock}</td>
                <td className="p-3 flex gap-2">
                  <EditProductDialog product={product} />
                  <DeleteProductDialog product={product} />
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
