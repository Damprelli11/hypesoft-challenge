import React, { useContext, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "@/auth/AuthContext";
import logo from "@/assets/logo.svg";

export default function LoginPage() {
  const { login, initialized, isAuthenticated } = useContext(AuthContext);
  const navigate = useNavigate();

  useEffect(() => {
    if (isAuthenticated) {
      navigate('/');
    }
  }, [isAuthenticated, navigate]);

  if (!initialized) {
    return (
      <div className="min-h-screen bg-gray-900 flex items-center justify-center">
        <p className="text-white">Carregando...</p>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-zinc-900 flex items-center justify-center px-4">
      <div className="bg-zinc-900 p-8 rounded-lg shadow-lg max-w-md w-full text-center">
        <img
          src={logo}
          alt="Hypesoft Logo"
          className="w-26 h-26 mx-auto mb-6"
        />
        <h1 className="text-2xl font-bold text-white mb-2">
          Hypesoft - Gestão
        </h1>
        <p className="text-gray-400 mb-6">Faça login para acessar o sistema.</p>
        <button
          onClick={() => {
            console.log("Login button clicked");
            login();
          }}
          className="w-full border-2 border-[#7d01ff] text-[#7d01ff] font-medium py-2 px-4 rounded-md hover:bg-[#7d01ff] hover:text-white transition duration-200"
        >
          Fazer Login com Keycloak
        </button>
      </div>
    </div>
  );
}