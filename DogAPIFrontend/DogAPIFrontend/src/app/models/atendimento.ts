export class Atendimento{
  atendimentoId = Number;
  dataDeAtendimento = Date();
  cachorroId = Number;
  veterinarioId = Number;
  diagnostico = String;
  comentario = String;
  pet = {cachorroId : Number};
  veterinario = {veterinarioId : Number}
  horarioDeAtendimento = new Date().getTime();
}

