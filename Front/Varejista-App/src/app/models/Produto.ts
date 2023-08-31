import { DecimalPipe } from "@angular/common";
import { Categoria } from "./Categoria";

export interface Produto {
  id: number;
  nome: string;
  preco: DecimalPipe;
  descricao: string;
  quantidade: number;

  categoria: Categoria[];
}
