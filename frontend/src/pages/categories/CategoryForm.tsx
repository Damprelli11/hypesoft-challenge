import { useForm } from "react-hook-form";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";

interface CategoryFormData {
  name: string;
}

interface CategoryFormProps {
  initialData?: CategoryFormData;
  isLoading?: boolean;
  onSubmit: (data: CategoryFormData) => void;
}

export function CategoryForm({
  initialData,
  isLoading,
  onSubmit,
}: CategoryFormProps) {
  const { register, handleSubmit } = useForm<CategoryFormData>({
    defaultValues: initialData,
  });

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
      <div>
        <Label>Nome</Label>
        <Input {...register("name", { required: true })} />
      </div>

      <Button className="w-full" disabled={isLoading}>
        {isLoading ? "Salvando..." : "Salvar"}
      </Button>
    </form>
  );
}
