import { Directive, ElementRef, Renderer2, HostListener, Output, EventEmitter, Input } from '@angular/core';
import { ParsingService } from '../services/parsing.service'
import { delay } from 'rxjs/operator/delay';

@Directive({
    selector: '[scroll]'
})
export class ScrollDirective {

    private scrollParam?: number;
    private nodeName?: number;
    private IsTimeOut: boolean = true;

    @Output() onScrollEnd: EventEmitter<any> = new EventEmitter();
    @Input() delay: number = 0;

    constructor(private element: ElementRef, private renderer: Renderer2) {

        element.nativeElement
    }

    @HostListener("window:scroll", ["$event"])
    onWindowScroll() {
        //In chrome and some browser scroll is given to body tag
        let pos = (document.documentElement.scrollTop || document.body.scrollTop) + document.documentElement.offsetHeight;
        let max = document.documentElement.scrollHeight;
        // pos/max will give you the distance between scroll bottom and and bottom of screen in percentage.
        if (pos >= max * 0.95 && this.IsTimeOut) {
            this.IsTimeOut = false;
            this.onScrollEnd.emit();
            setTimeout(() => { this.IsTimeOut = true; }, this.delay)
        }
    }
}