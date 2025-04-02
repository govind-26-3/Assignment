export class Register {

    firstName?:string;
    lastName?:string;
    email?:string;
    password?:string;

    constructor(firstName?:string,lastName?:string,email?:string,password?:string){
        this.firstName=firstName;
        this.lastName=lastName;
        this.email=email;
        this.password=password;
    }
}

export class RegistrationResponse {
    userId:string

    constructor(userId:string){
        this.userId=userId;
    }
}
