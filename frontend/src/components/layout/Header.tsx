export function Header() {
  return (
    <header className="h-16 border-b border-zinc-200 bg-white px-6 flex items-center justify-between">
      <h1 className="text-lg font-semibold">Dashboard</h1>

      <div className="flex items-center gap-3">
        <span className="text-sm text-zinc-600">Admin</span>
      </div>
    </header>
  );
}
