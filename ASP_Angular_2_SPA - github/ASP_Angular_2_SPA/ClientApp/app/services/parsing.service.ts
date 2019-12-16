import { Injectable } from "@angular/core";
import { Http } from '@angular/http';


@Injectable()
export class ParsingService {
    private url = "api/ParsingInfo";
    constructor(private http: Http)
    { }

    getParsing(parseUrl: string) {
       // if (parseUrl != undefined)
        return this.http.get('api/ParsingInfo/Get?url=' + parseUrl);
    }

    uploadData(parseUrl: string, nodeName: string, startIndex: number, endIndex: number)
    {
        return this.http.get(this.url + '/UploadData?url=' + parseUrl + "&nodeName=" + nodeName + "&startIndex=" + startIndex + "&endIndex=" + endIndex);
    }

    //getProduct(id: number) {
    //    return this.http.get(this.url+'/'+id);
    //}

    //createProduct(product: Product) {
    //    return this.http.post(this.url, product);
    //}
    //updateProduct(product: Product) {

    //    return this.http.put(this.url + '/' + product.id, product);
    //}
    //deleteProduct(id: number) {
    //    return this.http.delete(this.url + '/' + id);
    //}
}
