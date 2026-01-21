import { LogOut } from "lucide-react";
import { useContext } from "react";
import { AuthContext } from "@/auth/AuthContext";

export function Topbar() {
  const { logout } = useContext(AuthContext);

  return (
    <header className="h-16 border-b border-zinc-100 bg-white px-6 flex items-center justify-between">
      <h1 className="text-lg text-zinc-400">Hypesoft - Gestão</h1>

      <button onClick={logout} className="text-sm text-zinc-600 flex items-center gap-2">
        <LogOut size={18} />
        <span className="text-sm">Logout</span>
      </button>
    </header>
  );
}
