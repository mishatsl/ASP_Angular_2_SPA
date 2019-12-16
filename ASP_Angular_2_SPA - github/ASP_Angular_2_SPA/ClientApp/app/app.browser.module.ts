import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared,
        BrowserAnimationsModule
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl }
        //,
        //{ provide: IsLoading, useValue: IsLoading }
    ]
})
export class AppModule {
    public IsLoading: boolean = true;
}



export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
