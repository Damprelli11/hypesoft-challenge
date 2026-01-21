import { createBrowserRouter } from "react-router-dom";
import { DashboardLayout } from "@/components/layout/DashboardLayout";
import DashboardPage from "@/pages/dashboard/DashboardPage";
import ProductsPage from "@/pages/products/ProductsPage";
import CategoriesPage from "@/pages/categories/CategoriesPage";
import LoginPage from "@/pages/auth/LoginPage";

import { ProtectedRoute } from "@/auth/ProtectedRoute";

/**
 * Application router configuration using React Router.
 * Defines routes for login, dashboard, products, and categories.
 * Protected routes require authentication.
 */
export const router = createBrowserRouter([
  {
    path: "/login",
    element: <LoginPage />,
  },
  {
    element: (
      <ProtectedRoute>
        <DashboardLayout />
      </ProtectedRoute>
    ),
    children: [
      { path: "/", element: <DashboardPage /> },
      { path: "/products", element: <ProductsPage /> },
      { path: "/categories", element: <CategoriesPage /> },
    ],
  },
]);