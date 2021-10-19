import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'round'})
export class RoundPipe implements PipeTransform {
  transform(value: number, fixed: number): string {
    return this.abbreviateNumber(value, fixed);
  }

  abbreviateNumber(num: any , fixed: number): string {
    if (num === null) { return ''; }
    if (num === 0) { return '0'; }
    let b = (num).toPrecision(2).split("e"),
        k = b.length === 1 ? 0 : Math.floor(Math.min(b[1].slice(1), 14) / 3),
        c = k < 1 ? num.toFixed(0 + fixed) : (num / Math.pow(10, k * 3) ).toFixed(1 + fixed),
        d = c < 0 ? c : Math.abs(c),
        e = Math.round(d) + ['', 'K', 'M', 'B', 'T'][k];
    return e || '';
  }
}