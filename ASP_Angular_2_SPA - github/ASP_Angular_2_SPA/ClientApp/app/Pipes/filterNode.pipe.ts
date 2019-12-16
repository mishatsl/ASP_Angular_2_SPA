import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filterNode',
    pure: false
})
export class FilterNodePipe implements PipeTransform {
    transform(items: any[], arg?: any): any {
        if (!items || !arg) {
            return items;
        }
        // filter items array, items which match and return true will be
        // kept, false will be filtered out
        return items.filter(item => item.name.toLowerCase() === arg.toLowerCase()).sort((item1, item2) =>  item1.index - item2.index );
    }
}