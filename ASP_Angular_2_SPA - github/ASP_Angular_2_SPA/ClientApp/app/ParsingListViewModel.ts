import { PagingInfo } from './PagingInfo';
import { ParsingInfoSimplified } from './ParsingInfoSimplified';

export class ParsingListViewModel {
    constructor(
        public pagingInfo: PagingInfo = new PagingInfo(),
        public parsingInfoSimplifieds: ParsingInfoSimplified[] = []
    ) { }
}