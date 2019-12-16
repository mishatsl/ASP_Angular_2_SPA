import { trigger, transition, style, query, animateChild, group, animate, state } from "@angular/animations";


export const slideInAnimation =
    trigger('routeAnimations', [
        transition('url-parsing <=> saved-parsing', [
       // transition('* <=> *', [
            style({ position: 'relative' }),
            query(':enter, :leave', [
                style({
                    position: 'absolute',
                    top: 0,
                    left: 0,
                    width: '100%'
                })
            ]),
            query(':enter', [
                style({ left: '-100%' })
            ]),
            query(':leave', animateChild()),
            group([
                query(':leave', [
                    animate('300ms ease-out', style({ opacity: 0 }))
                ]),
                query(':enter', [
                    animate('300ms ease-out', style({ opacity: 1 }))
                ])
            ]),
            query(':enter', animateChild()),
        ])
       
    ]);

export const hideShowAnimation =
    trigger('hideShow', [
        // ...
        state('hide', style({
            opacity: 0,
            display:'none'
        })),
        state('show', style({
            opacity: 1,
            display: 'block'
        })),
        transition('* => hide', [
            animate('0.2s')
        ]),
        transition('* => show', [
            animate('0s')
        ])
    ]);

//import { trigger, animate, transition, style, query } from '@angular/animations';

//export const slideInAnimation =

//    trigger('routeAnimations', [

//        transition('*<=>*', [

//            query(':enter',
//                [
//                    style({ opacity: 0 }),
//                    animate('2s ease-out', style({ opacity: 1 }))
//                ],
//                { optional: true }
//            ),

//            query(':leave',
//                [
//                    style({ opacity: 1 }),
//                    animate('2s ease-out', style({ opacity: 0 }))
//                ],
//                { optional: true }
//            ),

//            query(':enter',
//                [
//                    style({ opacity: 0 }),
//                    animate('2s ease-out', style({ opacity: 1 }))
//                ],
//                { optional: true }
//            )

//        ])

//    ]);