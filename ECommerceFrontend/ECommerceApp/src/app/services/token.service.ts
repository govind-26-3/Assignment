import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }
  userRole: string | null = null;
 
  ngOnInit(){
    console.log(this.getUserRole())
  }
 
  getToken(): string | null {
    return localStorage.getItem('token');
  }
 
  getUserRole(): string | null {
    const tokenstring = this.getToken();
    if (!tokenstring) {
      return null;
    }
   
    try {
      const decodedToken: any = jwtDecode(tokenstring);
      this.userRole=decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']  || "";
      return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || null;
    } catch (error) {
      console.error('Invalid token:', error);
      return null;
    }
  }
 
  isAdmin(): boolean {
    console.log(this.userRole);
    return this.userRole == 'Admin';
  }
 
  isCustomer(): boolean {
    console.log(this.userRole );
 
    return this.userRole == 'User';
  }
}

function jwtDecode(tokenstring: string): any {
  const base64Url = tokenstring.split('.')[1];
  if (!base64Url) {
    throw new Error('Invalid token format');
  }
  const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
  const jsonPayload = decodeURIComponent(
    atob(base64)
      .split('')
      .map((c) => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
      .join('')
  );
  return JSON.parse(jsonPayload);
}


