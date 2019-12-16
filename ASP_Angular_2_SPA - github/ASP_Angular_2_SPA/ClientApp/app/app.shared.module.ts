import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
//import {  NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
//import {InfiniteScrollModule } from 'ngx-infinite-scroll';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
//import { HomeComponent } from './components/home/home.component';
//import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
//import { CounterComponent } from './components/counter/counter.component';
import { UrlparsingComponent } from './components/urlparsing/urlparsing.component';
import { ParsingService } from './services/parsing.service';
import { LoadingService } from './services/loading.service';
import { SavedParsingService } from './services/savedparsing.service';
import { TapsComponent } from './components/taps/taps.component';
import { LoadedParsingComponent } from './components/loadedparsing/loadedparsing.component';
import { SavedComponent } from './components/saved/saved.component';
import { FilterNodePipe } from './Pipes/filterNode.pipe';
import { ScrollDirective } from './directives/scroll.directive';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

export const IsLoading = true;

@NgModule({
    declarations: [
        //NgbModule,
        ScrollDirective,
        AppComponent,
        NavMenuComponent,
        //CounterComponent,
        //FetchDataComponent,
        UrlparsingComponent,
        //HomeComponent,
        TapsComponent,
        SavedComponent,
        LoadedParsingComponent,
        FilterNodePipe
    ],
    providers: [
        LoadingService,
        ParsingService,
        SavedParsingService
    ],
    imports: [
       // NgbModule,
        NgxPaginationModule,
        InfiniteScrollModule,
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'url-parsing', pathMatch: 'full' },
            //{ path: 'home', component: HomeComponent },
            //{ path: 'counter', component: CounterComponent },
            //{ path: 'fetch-data', component: FetchDataComponent },
            { path: 'url-parsing', component: UrlparsingComponent, data: { animation: 'url-parsing' }  },
            { path: 'loaded-parsing', component: LoadedParsingComponent },
            { path: 'saved-parsing', component: SavedComponent, data: { animation: 'saved-parsing' }  },
            { path: '**', redirectTo: 'url-parsing' }
        ])
    ]
})
export class AppModuleShared {
}
