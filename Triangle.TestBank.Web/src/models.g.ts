import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export enum WidgetCategory {
  Whizbangs = 0,
  Sprecklesprockets = 1,
  Discombobulators = 2,
}


export interface Widget extends Model<typeof metadata.Widget> {
  widgetId: number | null
  name: string | null
  category: WidgetCategory | null
  inventedOn: Date | null
}
export class Widget {
  
  /** Mutates the input object and its descendents into a valid Widget implementation. */
  static convert(data?: Partial<Widget>): Widget {
    return convertToModel(data || {}, metadata.Widget) 
  }
  
  /** Maps the input object and its descendents to a new, valid Widget implementation. */
  static map(data?: Partial<Widget>): Widget {
    return mapToModel(data || {}, metadata.Widget) 
  }
  
  /** Instantiate a new Widget, optionally basing it on the given data. */
  constructor(data?: Partial<Widget> | {[k: string]: any}) {
    Object.assign(this, Widget.map(data || {}));
  }
}


