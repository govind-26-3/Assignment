export class Login {
  email: string;
  password: string;

  constructor(email: string, password: string) {
    this.email = email;
    this.password = password;
  }
}

export class AuthResponseModel {
  token: string;
  id: string;
  userName: string;
  userEmail: string;

  constructor(
    token: string,
    id: string,
    userName: string,
    userEmail: string
  ) {
    this.token = token;
    this.id = id;
    this.userName = userName;

    this.userEmail = userEmail;
  }
}
