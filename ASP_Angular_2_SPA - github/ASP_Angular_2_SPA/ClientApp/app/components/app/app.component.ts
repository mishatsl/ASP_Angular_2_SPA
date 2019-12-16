import { Component, Inject } from '@angular/core';
import { RouterOutlet, Route, Router, NavigationEnd } from '@angular/router';
import { slideInAnimation, hideShowAnimation } from '../animations/animations'
import { LoadingService } from '../../services/loading.service';


@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    animations: [
        slideInAnimation,
        hideShowAnimation
        // animation triggers go here
        //fadeAnimation
    ]
})
export class AppComponent {

    constructor(private loadingService: LoadingService, private router: Router) {
        router.events.subscribe(val => {
            
            if (val instanceof NavigationEnd) {
                this.loadingService.IsLoading = true;
                console.log(this.loadingService.IsLoading);
            }
        }
        );
    }

    toggle() {
        this.loadingService.IsLoading = !this.loadingService.IsLoading;
    }

    prepareRoute(outlet: RouterOutlet) {
        return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
    }
}
