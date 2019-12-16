import { Component, ViewChild, ElementRef, OnInit, Inject, AfterViewInit} from '@angular/core';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
import { ParsingService } from '../../services/parsing.service';
import { ParsingInfo, NodeInfo } from '../../ParsingInfo';
import { TapsComponent } from '../taps/taps.component';
import { SavedParsingService } from '../../services/savedparsing.service';
import { window } from 'rxjs/operator/window';
import { Router } from '@angular/router';
import * as $ from 'jquery';
import * as bootstrap from 'bootstrap';
import { hideShowAnimation } from '../animations/animations';
import { LoadingService } from '../../services/loading.service';



@Component({
    selector: 'urlparsing',
    styleUrls: ['./urlparsing.component.css'],
    templateUrl: './urlparsing.component.html',
    animations: [hideShowAnimation]
})
export class UrlparsingComponent implements OnInit, AfterViewInit {

   
    

   // @ViewChild('TapsComponent') private TapsComponent: TapsComponent | undefined;

    public parsingInfo: ParsingInfo = new ParsingInfo();
    public parsingLoaded: boolean = false;
    public url: string = "";
    public router: Router;
    private nodeName: string = "";
    private nodeCount: number = 9;
    error: string = "incorrect URL";
    // public temp: ParsingInfo = new ParsingInfo();
    IsLoading: boolean = false;
    IsParsing: boolean = false;
    IsSaving: boolean = false;
    constructor(private parsingService: ParsingService, private savedParsingService: SavedParsingService, router: Router, private loadingService: LoadingService) {
        this.parsingInfo.nodesInfoList = [];
        this.parsingInfo.url = "https://dou.ua/";
        this.router = router;
        let titles = this.parsingInfo.nodesInfoList.filter((n) => n.name == 'title');
    }

    ngOnInit(): void {
        //"use strict";
       // this.IsLoading = true;
      //  this.IsLoaded = true;
        $(document).ready(function () {
            $('#myTabs a').click(function (e) {
                e.preventDefault();
                //$.noConflict();
                $('this').tab('show');
            })
        })
    }

    ngAfterViewInit(): void {
        this.loadingService.IsLoading = false;
        console.log(this.IsLoading);
    }

    //ngOnInit() {
    //    this.load();
    //}
    load(formData?: any) {
        //this.IsLoading = true;
        this.loadingService.IsLoading = true;
        // url = this.parsingInfo.url;
        this.parsingService.getParsing(this.parsingInfo.url).
            subscribe((data) => {
                this.parsingInfo = data.json() as ParsingInfo;
                this.IsParsing = false;
                this.parsingLoaded = true;
                this.loadingService.IsLoading = false;
            }, error => {
                this.error = error; formData.form.controls['url'].setErrors({ 'incorrect': true });
                this.IsParsing = false;
                this.parsingLoaded = false;
                this.loadingService.IsLoading = false;
            });
        
    }

    

    public douUrl() {
        this.parsingInfo.url = "https://dou.ua/";
    }

    save() {
        this.loadingService.IsLoading = true;
        this.IsSaving = true;
        this.savedParsingService.createParsingInfo(this.parsingInfo).subscribe((data) => {
            this.router.navigate(['/saved-parsing']);
        });
    }


    public parse(url?: string, formData?: any) {

        this.IsParsing = true;
        this.load(formData);
        
    }

    onScrollDown() {

        //In chrome and some browser scroll is given to body tag
        //let pos =  document.documentElement.offsetHeight;
        //let max = document.documentElement.scrollHeight;
        //// pos/max will give you the distance between scroll bottom and and bottom of screen in percentage.
        //if (pos == max) {
            let activeDiv = document.getElementsByClassName("active")[1];
            this.nodeName = activeDiv.id;// $(".active").attr("id");
            let arr = this.parsingInfo.nodesInfoList.filter(n => n.name.toLowerCase() == this.nodeName.toLowerCase());// activeDiv.childNodes.length - 1;
            this.nodeCount = arr.length;
            //if (this.nodeCount > Number.parseInt(Object.keys(this.parsingInfo).find(k => k.toLowerCase() == this.nodeName.toLowerCase() + "Count"))
            //{internalAHREF  internalAHREFS
            //}
            this.parsingService.uploadData(this.parsingInfo.url, this.nodeName, this.nodeCount, this.nodeCount + 10)
                .subscribe((data) => { this.parsingInfo.nodesInfoList = this.parsingInfo.nodesInfoList.concat(data.json() as NodeInfo[]); this.nodeCount += 9; }, error => console.error(error));

      //  }
          

    }
}
   