import { LogOut } from "lucide-react";

export function Topbar() {
  return (
    <header className="h-16 border-b border-zinc-100 bg-white px-6 flex items-center justify-between">
      <h1 className="text-lg text-zinc-400">Hypesoft - Gestão</h1>

      <button className="text-sm text-zinc-600">
        <LogOut size={18} />
        <span className="text-sm">Logout</span>
      </button>
    </header>
  );
}
