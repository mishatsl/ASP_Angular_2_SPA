import { Observable } from 'rxjs';

//export class ParsingInfo {
   
        
//    constructor(
//        public id?: number,
//        public parsingName?: string,
//        public titles?: NodeInfo[],
//        public descriptions?: NodeInfo[],
//        public serverResponces?: number,
//        public responseTime?: string,
//        public h1s?: NodeInfo[],
//        public imagess?: NodeInfo[],
//        public tnternalAHREFS?: NodeInfo[],
//        public externalAHREFS?: NodeInfo[],
//        public titleCount?: number,
//        public descriptionCount?: number,
//        public h1Count?: number,
//        public imagesCount?: number,
//        public innerAHREFSCount?: number,
//        public outerAHREFSCount?: number
//    )
//    { }

    //    constructor(
    //            public id?: Observable<number>,
    //            public titles?: Observable<Object>,
    //            public descriptions?: Observable<Object>,
    //            public serverResponces?: Observable<number>,
    //            public responseTime?: Observable<Object>,
    //            public h1s?: Observable<Object>,
    //            public imagess?: Observable<Object>,
    //            public tnternalAHREFS?: Observable<Object>,
    //            public externalAHREFS?: Observable<Object>,
    //            public titleCount?: Observable<number>,
    //            public descriptionCount?: Observable<number>,
    //            public h1Count?: Observable<number>,
    //            public imagesCount?: Observable<number>,
    //            public innerAHREFSCount?: Observable<number>,
    //            public outerAHREFSCount?: Observable<number>
    //)
    //{ }

export class ParsingInfo {


    constructor(
        public titleCount: number = 0,
        public descriptionCount: number = 0,
        public h1Count: number = 0,
        public imagesCount: number = 0,
        public innerAHREFSCount: number = 0,
        public outerAHREFSCount: number = 0,
        public url: string = "",
        public parsingName: string = "",
        public serverResponces: number = 0,
        public responseTime: string = "",
        public nodesInfoList: NodeInfo[] = [],
        public id?: number,
       
    ) { }
   
}
export class NodeInfo {
    constructor(
    public nodeInfoId?: number,
    public index?: number,
    public name: string = "",
    public outerHtml?: string,
    public content?: string,
    public parsingInfoId?: number
    )
    { }
}


  