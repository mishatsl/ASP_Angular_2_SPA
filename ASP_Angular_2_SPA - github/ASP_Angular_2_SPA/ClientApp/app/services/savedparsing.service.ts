import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import { ParsingInfo } from "../ParsingInfo";
import { PagingInfo } from '../PagingInfo';


@Injectable()
export class SavedParsingService {
    private url = "api/SavedParsingInfoes";
    constructor(private http: Http) { }

    getParsingInfos(page: number = 1) {
        return this.http.get('api/SavedParsingInfoes/GetParsingInfoSimplified?page=' + page);
    }

    getParsingInfo(id: number = 1) {
        return this.http.get('api/SavedParsingInfoes/GetParsingInfo?id=' + id);
    }
    //getParsing(parseUrl: string) {
    //    // if (parseUrl != undefined)
    //    return this.http.get(this.url + '?url=' + parseUrl);
    //}
    createParsingInfo(parsingInfo: ParsingInfo) {
        return this.http.post('api/SavedParsingInfoes/Post', parsingInfo);
    }


    deleteParsingInfo(id: number) {
        return this.http.delete('api/SavedParsingInfoes/Delete?id=' + id);
    }
}
