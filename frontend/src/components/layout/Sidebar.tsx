import { Link, useLocation } from "react-router-dom";
import { Package, LayoutDashboard, Folder } from "lucide-react";
import logo from "@/assets/logo.svg?url";

const menu = [
  { label: "Dashboard", path: "/", icon: LayoutDashboard },
  { label: "Produtos", path: "/products", icon: Package },
  { label: "Categorias", path: "/categories", icon: Folder },
];

export function Sidebar() {
  const location = useLocation();

  return (
    <aside className="w-64 bg-zinc-900 text-white min-h-screen">
      <div className="p-6 flex items-center gap-3">
        <img src={logo} alt="Hypesoft Logo" className="h-8 w-13" />
      </div>

      <nav className="space-y-1 px-4">
        {menu.map((item) => {
          const active = location.pathname === item.path;
          const Icon = item.icon;

          return (
            <Link
              key={item.path}
              to={item.path}
              className={`flex items-center gap-3 rounded-lg px-3 py-2 text-sm font-medium transition
                ${
                  active
                    ? "bg-zinc-800 text-white"
                    : "text-zinc-400 hover:bg-[#7d01ff] hover:text-white"
                }
              `}
            >
              <Icon size={18} />
              {item.label}
            </Link>
          );
        })}
      </nav>
    </aside>
  );
}
