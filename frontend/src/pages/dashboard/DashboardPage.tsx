import { useContext } from "react";
import { AuthContext } from "@/auth/AuthContext";

export default function DashboardPage() {
  const { roles } = useContext(AuthContext);

  return (
    <div>
      <h1 className="text-2xl font-bold">Dashboard</h1>
      <p className="text-zinc-400 mt-2">
        Bem-vindo ao sistema Hypesoft de Gestão de Produtos (Desenvolvido por{" "}
        <a
          href="https://github.com/Damprelli11"
          target="_blank"
          className="hover:text-purple-500"
        >
          Renan Damprelli
        </a>
        ).
      </p>

    </div>
  );
}
