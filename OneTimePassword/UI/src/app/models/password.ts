export class Password {
    dateCreation: Date;
    accessCode: string;

    remainingTime: number;
    isDisplayed: boolean;

    constructor(){
        this.isDisplayed = false;
    }
}
