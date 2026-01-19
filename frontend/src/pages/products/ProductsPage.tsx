import { useProducts } from "@/hooks/useProducts";

export default function ProductsPage() {
  const { data, isLoading, error } = useProducts();

  if (isLoading) {
    return <p className="text-zinc-400">Carregando produtos...</p>;
  }

  if (error) {
    return <p className="text-red-500">Erro ao carregar produtos</p>;
  }

  return (
    <div>
      <h1 className="text-2xl font-bold mb-4">Products</h1>

      <div className="rounded-lg border border-zinc-800 overflow-hidden">
        <table className="w-full text-sm">
          <thead className="bg-zinc-900 text-zinc-400">
            <tr>
              <th className="p-3 text-left">Name</th>
              <th className="p-3 text-left">Category</th>
              <th className="p-3 text-left">Price</th>
              <th className="p-3 text-left">Stock</th>
            </tr>
          </thead>

          <tbody>
            {data?.map((product) => (
              <tr
                key={product.id}
                className="border-t border-zinc-800 hover:bg-zinc-900"
              >
                <td className="p-3">{product.name}</td>
                <td className="p-3">{product.category}</td>
                <td className="p-3">R$ {product.price.toFixed(2)}</td>
                <td className="p-3">{product.stock}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
