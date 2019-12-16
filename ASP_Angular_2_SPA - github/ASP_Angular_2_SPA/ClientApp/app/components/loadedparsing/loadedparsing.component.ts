import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { SavedParsingService } from '../../services/savedparsing.service';
import { ParsingInfoSimplified } from '../../ParsingInfoSimplified';
import { ParsingInfo } from '../../ParsingInfo';
import { Router, ActivatedRoute } from '@angular/router';
import { hideShowAnimation } from '../animations/animations';
import { LoadingService } from '../../services/loading.service'

@Component({
    selector: 'loadedparsing',
    templateUrl: './loadedparsing.component.html',
    animations: [hideShowAnimation]
})
export class LoadedParsingComponent implements OnInit {


    public id: number = -1;
    public parsingInfo: ParsingInfo = new ParsingInfo();
    //parsingInfoSimplified: ParsingInfoSimplified = new ParsingInfoSimplified();    // изменяемый объект
    loaded: boolean = false;
    secondLoad: string;

    constructor(private savedParsingService: SavedParsingService, private router: Router, public activatedRouter: ActivatedRoute, private loadingService: LoadingService) {
       // this.id = Number.parseInt(activatedRouter.snapshot.params["id"]);
        this.parsingInfo.nodesInfoList = [];
        this.parsingInfo.url = "";
        this.secondLoad = "Second load conctructor!"
    }

    ngOnInit() {
        this.activatedRouter.queryParams.subscribe(params => {
          //  this.id = params["id"];
           
            this.savedParsingService.getParsingInfo(params["id"]).subscribe(data => {
                    this.parsingInfo = data.json() as ParsingInfo;
                   // if (this.parsingInfo != null)
                this.loaded = true;
                this.loadingService.IsLoading = false;
                }, error => console.error(error));
        });
        


    }

    
}