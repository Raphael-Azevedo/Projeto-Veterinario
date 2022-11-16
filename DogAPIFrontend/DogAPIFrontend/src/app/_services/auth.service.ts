import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse  } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { Usuario } from '../models/usuario';
import { Veterinario } from '../models/veterinario';
import { Cachorro } from '../models/cachorro';
import { Cliente } from '../models/cliente';
import { Atendimento } from '../models/atendimento';
import { Raca } from '../models/raca';
import { Image } from '../models/image';
import { racaSearch } from '../models/racaSearch';

const AUTH_API = 'https://localhost:5001/api/v1/Autorization';
const VET_API = 'https://localhost:5001/api/v1/Veterinarios';
const PET_API = 'https://localhost:5001/api/v1/Cachorros';
const CLIENTE_API = 'https://localhost:5001/api/v1/Clientes';
const ATEND_API = 'https://localhost:5001/api/v1/Atendimentos';
const USER_API = 'https://localhost:5001/api/v1/Usuario';

var token;
var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }


  register(Usuario:Usuario): Observable<Usuario> {
    const apiUrl = `${AUTH_API}/register`;
    return this.http.post<Usuario>(apiUrl, Usuario,httpOptions).pipe(
      tap((Usuario: Usuario) => console.log(`registro do usuario com email =${Usuario.email}`)));
  }

  montaHeaderToken() {
    token = sessionStorage.getItem("auth-token");
    console.log('jwt header token ' + token);
    httpOptions = {headers: new HttpHeaders({"Authorization": "Bearer " + token,"Content-Type": "application/json"})};
  }

  login (Usuario:Usuario): Observable<Usuario> {
    const apiUrl = `${AUTH_API}/login`;
    return this.http.post<Usuario>(apiUrl, Usuario).pipe(
      tap((Usuario: Usuario) => console.log(`Login usuario com email =${Usuario.email}`))
    );
  }
  public handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

  getRaca (): Observable<Raca[]> {
    this.montaHeaderToken();
    const apiUrl = `${USER_API}/breeds`;
    return this.http.get<Raca[]>(apiUrl, httpOptions)
      .pipe(
        tap(Raca => console.log('leu as Raca')),
        catchError(this.handleError('getRaca', []))
      );
  }
  getRacas (raca:racaSearch): Observable<racaSearch> {
    this.montaHeaderToken();
    console.log(httpOptions);
    const apiUrl = `${USER_API}/search`;
    return this.http.post<racaSearch>(apiUrl, raca, httpOptions).pipe(
      tap((Veterinario: racaSearch) => console.log(`buscou uma raca `)),
      catchError(this.handleError<racaSearch>('addVeterinario'))
    );
  }


  getImagem (): Observable<Image[]> {
    this.montaHeaderToken();
    const apiUrl = `${USER_API}/images`;
    return this.http.get<Image[]>(apiUrl, httpOptions)
      .pipe(
        tap(Image => console.log('leu as Imagens')),
        catchError(this.handleError('getImage', []))
      );
  }


  getVeterinarios (): Observable<Veterinario[]> {
    this.montaHeaderToken();
    const apiUrl = `${VET_API}/all`;
    return this.http.get<Veterinario[]>(apiUrl, httpOptions)
      .pipe(
        tap(Veterinarios => console.log('leu os Veterinarios')),
        catchError(this.handleError('getVeterinarios', []))
      );
  }
  getVeterinarioCRMV(crmv: string): Observable<Veterinario> {
    this.montaHeaderToken();
    const url = `${VET_API}/crmv/${crmv}`;
    return this.http.get<Veterinario>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Veterinario crmv=${crmv}`)),
      catchError(this.handleError<Veterinario>(`getVeterinario crmv=${crmv}`))
    );
  }

  getVeterinario(id: number): Observable<Veterinario> {
    this.montaHeaderToken();
    const url = `${VET_API}/${id}`;
    return this.http.get<Veterinario>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Veterinario id=${id}`)),
      catchError(this.handleError<Veterinario>(`getVeterinario id=${id}`))
    );
  }

  addVeterinario (Veterinario:Veterinario): Observable<Veterinario> {
    this.montaHeaderToken();
    return this.http.post<Veterinario>(VET_API, Veterinario, httpOptions).pipe(
      tap((Veterinario: Veterinario) => console.log(`adicionou um Veterinario `)),
      catchError(this.handleError<Veterinario>('addVeterinario'))
    );
  }

  updateVeterinario(id = Number, Veterinario:Veterinario): Observable<any> {
    this.montaHeaderToken();
    const url = `${VET_API}/${id}`;
    return this.http.put(url, Veterinario, httpOptions).pipe(
      tap(_ => console.log(`atualiza o veterinario com id=${id}`)),
      catchError(this.handleError<any>('updateVeterinario'))
    );
  }

  deleteVeterinario(id:number): Observable<Veterinario> {
    this.montaHeaderToken();
    const url = `${VET_API}/${id}`;
    return this.http.delete<Veterinario>(url, httpOptions).pipe(
      tap(_ => console.log(`remove o Veterinario com id=${id}`)),
      catchError(this.handleError<Veterinario>('deleteVeterinario'))
    );
  }


  getPets (): Observable<Cachorro[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    const apiUrl = `${PET_API}/all`;
    return this.http.get<Cachorro[]>(apiUrl,  httpOptions)
      .pipe(
        tap(Cachorro => console.log('leu os Cachorro')),
        catchError(this.handleError('getCachorros', []))
      );
  }
  getPetCPF(cpf: string): Observable<Cachorro> {
    this.montaHeaderToken();
    const url = `${PET_API}/tutor/${cpf}`;
    return this.http.get<Cachorro>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Cachorro cpf=${cpf}`)),
      catchError(this.handleError<Cachorro>(`getCachorro cpf=${cpf}`))
    );
  }

  getPet(id: number): Observable<Cachorro> {
    this.montaHeaderToken();
    const url = `${PET_API}/${id}`;
    return this.http.get<Cachorro>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Cachorro id=${id}`)),
      catchError(this.handleError<Cachorro>(`getCachorro id=${id}`))
    );
  }

  addPet(Cachorro:Cachorro): Observable<Cachorro> {
    this.montaHeaderToken();
    return this.http.post<Cachorro>(PET_API, Cachorro, httpOptions).pipe(
      tap((Cachorro: Cachorro) => console.log(`adicionou um Cachorro `)),
      catchError(this.handleError<Cachorro>('addCachorro'))
    );
  }

  updatePet(id = Number, Cachorro:Cachorro): Observable<any> {
    this.montaHeaderToken();
    const url = `${PET_API}/${id}`;
    return this.http.put(url, Cachorro, httpOptions).pipe(
      tap(_ => console.log(`atualiza o Cachorro com id=${id}`)),
      catchError(this.handleError<any>('updateCachorro'))
    );
  }

  deletePet(id:number): Observable<Cachorro> {
    this.montaHeaderToken();
    const url = `${PET_API}/${id}`;
    return this.http.delete<Cachorro>(url, httpOptions).pipe(
      tap(_ => console.log(`remove o Cachorro com id=${id}`)),
      catchError(this.handleError<Cachorro>('deleteCachorro'))
    );
  }


  getClientes (): Observable<Cliente[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    const apiUrl = `${CLIENTE_API}/all`;
    return this.http.get<Cliente[]>(apiUrl, httpOptions)
      .pipe(
        tap(Cliente => console.log('leu os Clientes')),
        catchError(this.handleError('getClientes', []))
      );
  }
  getClienteCPF(cpf: string): Observable<Cliente> {
    this.montaHeaderToken();
    const url = `${CLIENTE_API}/cpf/${cpf}`;
    return this.http.get<Cliente>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Cliente cpf=${cpf}`)),
      catchError(this.handleError<Cliente>(`getCliente cpf=${cpf}`))
    );
  }

  getCliente(id: number): Observable<Cliente> {
    this.montaHeaderToken();
    const url = `${CLIENTE_API}/${id}`;
    return this.http.get<Cliente>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Cliente id=${id}`)),
      catchError(this.handleError<Cliente>(`getCliente id=${id}`))
    );
  }

  addCliente(Cliente:Cliente): Observable<Cliente> {
    this.montaHeaderToken();
    return this.http.post<Cliente>(CLIENTE_API, Cliente, httpOptions).pipe(
      tap((Cliente: Cliente) => console.log(`adicionou um Cliente `)),
      catchError(this.handleError<Cliente>('addCliente'))
    );
  }

  updateCliente(id = Number, Cliente:Cliente): Observable<any> {
    this.montaHeaderToken();
    const url = `${CLIENTE_API}/${id}`;
    return this.http.put(url, Cliente, httpOptions).pipe(
      tap(_ => console.log(`atualiza o Cliente com id=${id}`)),
      catchError(this.handleError<any>('updateCliente'))
    );
  }

  deleteCliente(id:number): Observable<Cliente> {
    this.montaHeaderToken();
    const url = `${CLIENTE_API}/${id}`;
    return this.http.delete<Cliente>(url, httpOptions).pipe(
      tap(_ => console.log(`remove o Cliente com id=${id}`)),
      catchError(this.handleError<Cliente>('deleteCliente'))
    );
  }

  getAtendimentos (): Observable<Atendimento[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    const apiUrl = `${ATEND_API}/all`;
    return this.http.get<Atendimento[]>(apiUrl, httpOptions)
      .pipe(
        tap(Atendimento => console.log('leu os Atendimentos')),
        catchError(this.handleError('getAtendimentos', []))
      );
  }
  getAtendimentosUser (email:string): Observable<Atendimento[]> {
    this.montaHeaderToken();
    console.log(httpOptions.headers);
    const apiUrl = `${USER_API}/tutor/${email}`;
    return this.http.get<Atendimento[]>(apiUrl, httpOptions)
      .pipe(
        tap(Atendimento => console.log('leu os Atendimentos')),
        catchError(this.handleError('getAtendimentos', []))
      );
  }
  getAtendimentoCPF(cpf: string): Observable<Atendimento> {
    this.montaHeaderToken();
    const url = `${ATEND_API}/tutor/${cpf}`;
    return this.http.get<Atendimento>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Atendimento cpf=${cpf}`)),
      catchError(this.handleError<Atendimento>(`getAtendimento cpf=${cpf}`))
    );
  }
  getAtendimentoPetName(petName: string): Observable<Atendimento> {
    this.montaHeaderToken();
    const url = `${ATEND_API}/pet/${petName}`;
    return this.http.get<Atendimento>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Atendimento petName=${petName}`)),
      catchError(this.handleError<Atendimento>(`getAtendimento petName=${petName}`))
    );
  }
  getAtendimento(id: number): Observable<Atendimento> {
    this.montaHeaderToken();
    const url = `${ATEND_API}/${id}`;
    return this.http.get<Atendimento>(url, httpOptions).pipe(
      tap(_ => console.log(`leu o Atendimento id=${id}`)),
      catchError(this.handleError<Atendimento>(`getAtendimento id=${id}`))
    );
  }

  addAtendimento(Atendimento:Atendimento): Observable<Atendimento> {
    this.montaHeaderToken();
    return this.http.post<Atendimento>(ATEND_API, Atendimento, httpOptions).pipe(
      tap((Atendimento: Atendimento) => console.log(`adicionou um Atendimento `)),
      catchError(this.handleError<Atendimento>('addAtendimento'))
    );
  }

  updateAtendimento(id = Number, Atendimento:Atendimento): Observable<any> {
    this.montaHeaderToken();
    const url = `${ATEND_API}/${id}`;
    return this.http.put(url, Atendimento, httpOptions).pipe(
      tap(_ => console.log(`atualiza o Atendimento com id=${id}`)),
      catchError(this.handleError<any>('updateAtendimento'))
    );
  }

  deleteAtendimento(id:number): Observable<Atendimento> {
    this.montaHeaderToken();
    const url = `${ATEND_API}/${id}`;
    return this.http.delete<Atendimento>(url, httpOptions).pipe(
      tap(_ => console.log(`remove o Atendimento com id=${id}`)),
      catchError(this.handleError<Atendimento>('deleteAtendimento'))
    );
  }
}
