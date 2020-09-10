import {Client, IClient} from "../../shared/generated";
import {InjectionToken} from "@angular/core";

const clientServiceFactory = () => new Client('https://localhost:5001'); //TODO url брать из настроек
export const clientServiceToken = new InjectionToken<IClient>('');
export const clientServiceProvider = { provide: clientServiceToken, useFactory: clientServiceFactory };
