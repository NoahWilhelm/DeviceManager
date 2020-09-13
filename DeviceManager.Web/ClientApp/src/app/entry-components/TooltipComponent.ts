import { Component, Input } from "@angular/core";

@Component({
  selector: 'x-tooltip',
  template: '{{ text }}',
  styles: [
    "x-tooltip { padding: 2px; background: black; color: white; }"
  ]
})
export class TooltipComponent {

  @Input() text: string = '';



}
