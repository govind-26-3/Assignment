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
  userId: string;
  userName: string;
  userEmail: string;

  constructor(
    token: string,
    userId: string,
    userName: string,
    userEmail: string
  ) {
    this.token = token;
    this.userId = userId;
    this.userName = userName;

    this.userEmail = userEmail;
  }
}
