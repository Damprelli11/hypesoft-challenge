import { createBrowserRouter } from "react-router-dom";
import { DashboardLayout } from "@/components/layout/DashboardLayout";
import DashboardPage from "@/pages/dashboard/DashboardPage";
import ProductsPage from "@/pages/products/ProductsPage";
import CategoriesPage from "@/pages/categories/CategoriesPage";

export const router = createBrowserRouter([
  {
    element: <DashboardLayout />,
    children: [
      { path: "/", element: <DashboardPage /> },
      { path: "/products", element: <ProductsPage /> },
      { path: "/categories", element: <CategoriesPage /> },
    ],
  },
]);
