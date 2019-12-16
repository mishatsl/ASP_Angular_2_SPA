import { Injectable } from "@angular/core";

@Injectable()
export class LoadingService {
    private _IsLoading: boolean = true;

    get IsLoading(): boolean {
        return this._IsLoading;
    }
    set IsLoading(IsLoading: boolean) {
        this._IsLoading = IsLoading;
    }
}