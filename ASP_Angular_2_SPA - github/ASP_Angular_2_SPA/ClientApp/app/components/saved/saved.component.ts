import { Component, Inject, OnInit, AfterViewInit,  } from '@angular/core';
import { Http } from '@angular/http';
import { SavedParsingService } from '../../services/savedparsing.service';
import { ParsingInfo } from '../../ParsingInfo';
import { ParsingInfoSimplified } from '../../ParsingInfoSimplified';
import { ParsingListViewModel } from '../../ParsingListViewModel';
import { ActivatedRoute, Router } from '@angular/router';
import { hideShowAnimation } from '../animations/animations';
import { LoadingService } from '../../services/loading.service';

@Component({
    selector: 'saved',
    templateUrl: './saved.component.html',
    animations: [hideShowAnimation]
})
export class SavedComponent implements OnInit, AfterViewInit {

    ngAfterViewInit(): void {
   //     this.IsLoading = false;
    }
    savedParsingService: SavedParsingService;
    public currentPage: number = -1;
    public totalItems: number = 0; // total numbar of page not items
    public maxSize: number = 9; // max page size


    public parsingListViewModel: ParsingListViewModel = new ParsingListViewModel();
    public parsingInfoSimplifieds: ParsingInfoSimplified[] | undefined;
    dataLoaded: boolean = false;
    

    constructor(savedParsingService: SavedParsingService, private routeActive: ActivatedRoute, private router: Router, private loadingService: LoadingService) {
        this.savedParsingService = savedParsingService;
    }

    ngOnInit() {
        //this.IsLoading = true;
        this.LoadParsingInfoSimplifieds();
    }

    LoadParsingInfoSimplifieds() {
        //this.IsLoading = true;
        this.routeActive.queryParams.subscribe(
                (queryParam: any) => {
                 //   if (typeof queryParam['page'] === "number")
                        this.currentPage = queryParam['page'];
        this.savedParsingService.getParsingInfos(this.currentPage).subscribe((data) => {
            this.parsingListViewModel = data.json() as ParsingListViewModel;
            this.maxSize = this.parsingListViewModel.pagingInfo.maxSize;
            this.totalItems = this.parsingListViewModel.pagingInfo.totalItems;
            this.dataLoaded = true;
            this.loadingService.IsLoading = false;
            //this.routeActive.queryParams.subscribe(
            //    (queryParam: any) => {
            //        if (typeof queryParam['page'] === "number")
            //            this.currentPage = queryParam['page'];
                });
        });
    }

    

    delete(parsingInfoSimplifiedId: number) {
        this.savedParsingService.deleteParsingInfo(parsingInfoSimplifiedId).subscribe(data => this.LoadParsingInfoSimplifieds());
    }

    //public setPage(pageNo: number): void {
    //    this.currentPage = pageNo;
    //     };

    pagechanged($event: number) {
       // this.currentPage = $event;
        //this method will trigger every page click 
        this.router.navigate(['/saved-parsing'],
            {
            queryParams: {
                'page': $event
            }
        });
        this.LoadParsingInfoSimplifieds();
        //this.savedParsingService.getParsingInfos($event).subscribe(data => {
        //    this.routeActive.queryParams.subscribe(
        //        (queryParam: any) => {
        //            queryParam['page'] = this.currentPage;
        //        });
        //    this.LoadParsingInfoSimplifieds()
        //});

    };
    
}

