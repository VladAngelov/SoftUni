import { Directive, DoCheck, Input, OnChanges, SimpleChanges } from '@angular/core';

@Directive({
  selector: '[appIsEmpty]',
  exportAs: 'isEmpty'
})
export class IsEmptyDirective implements OnChanges, DoCheck {

  @Input() someValue: any;

  isEmpty = true;

  constructor() { }

  ngDoCheck(): void {
    this.isEmpty = !this.someValue;
  }

  ngOnChanges(simpleChanges: SimpleChanges): void {
    this.isEmpty = !simpleChanges?.someValue.currentValue || true;
  }
}
