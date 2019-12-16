import { Component, Input, AfterViewInit, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ParsingInfo } from '../../ParsingInfo';
import * as $ from 'jquery';
import * as bootstrap from 'bootstrap';

//declare var $: any;
//declare var WOW: any;

@Component({
    selector: 'taps',
    templateUrl: 'taps.component.html'
})
export class TapsComponent implements AfterViewInit, OnInit  {

    ngOnInit(): void {
        "use strict";
        $(document).ready(function () {
            $('#myTabs a').click(function (e) {
                e.preventDefault();
                $.noConflict();
                $('this').tab('show');
            })
        })
    }
    ngAfterViewInit(): void {
        
        //($)=> { };
        
    }
    @Input() parsingInfo: ParsingInfo | undefined ; 
}
