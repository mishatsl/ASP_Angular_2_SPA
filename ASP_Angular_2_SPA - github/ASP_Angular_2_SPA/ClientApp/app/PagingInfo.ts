
export class PagingInfo {
    constructor(
        public currentPage: number = 1,
        public totalItems: number = 0, // total numbar of page not items
        public maxSize: number = 9 // max page size

    ) { }
}